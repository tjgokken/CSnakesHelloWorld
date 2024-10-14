import statistics
import pandas as pd

def process_numbers(numbers: list[float]) -> dict[str, float]:
    result = {
        "mean": statistics.mean(numbers),
        "median": statistics.median(numbers),
        "stdev": statistics.stdev(numbers) if len(numbers) > 1 else 0.0
    }
    return result

def hello_world(name: str) -> str:
    return f"Hello, {name}!"

def summarize_data(csv_path: str) -> str:
    df = pd.read_csv(csv_path)
    return df.describe().to_string()
